  <SkeletonTheme baseColor="#202020" highlightColor="#171717">
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<LandingPage />} />
          <Route path="/home" element={<AuthenticatedLayout />}>
            <Route
              path="email-redirect/:roomId"
              element={<EmailRedirectionPage />}
            />
            <Route path="landing" element={<LandingPage />} />
            <Route path="projects" element={<ProjectsPage />} />
            <Route path="projects/:projectId" element={<ProjectPage />} />
            <Route path="chatPage/:roomId" element={<ChatPage />} />
            <Route path="leaderboard" element={<LeaderBoardPage />} />
            <Route path="collaboration" element={<CollaborationUnderDev />} />
            <Route path="userprojects" element={<UserOwnedProjectsPage />} />
            {/* <CollaborationPage /> */}
            <Route path="projects/create" element={<CreatePostPage />} />.
            <Route path="developer-talent-pool" element={<TalentPoolPage />} />
            <Route path="password-reset" element={<PasswordResetPage />} />
                </Routes>
      </BrowserRouter>
    </SkeletonTheme>
      );
}
export default App;
